using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArchiTetris
{
    public class ReadWriteLock
    {
        public int waitingForReadLock = 0;
        private List<Thread> waitingForWriteLock = new List<Thread>();
        private Thread writeLockedThread;
        private Object o = new Object();
        private ArchiTetris env;

        public ReadWriteLock(ArchiTetris e)
        {
            env = e;
        }

        public BlockIF getBlock()
        {
            readLock();
            BlockIF b = env.nextBlocks.Dequeue();
            done();
            return b;
        }

        public void addBlock(BlockIF newB)
        {
            writeLock();
            env.nextBlocks.Enqueue(newB);
            done();
        }

        public void readLock()
        {
            lock (this)
            {
                waitingForReadLock++;
                if (writeLockedThread != null)
                {
                    while (writeLockedThread != null)
                    {
                        Monitor.Wait(this);
                    }
                }
            }
        }

        public void writeLock()
        {
            Thread thisThread = Thread.CurrentThread;
            lock (this) {
                if (writeLockedThread == null && waitingForReadLock == 0)
                {
                    writeLockedThread = thisThread;
                    return;
                }
                waitingForWriteLock.Add(thisThread);
            }
            lock (o) {
                while (thisThread != writeLockedThread)
                {
                    Monitor.Wait(o);
                }
            }
            lock (this) {
                waitingForWriteLock.Remove(thisThread);
            }
        }

        public void done()
        {
            lock (this)
            {
                if (Thread.CurrentThread == writeLockedThread)
                {
                    writeLockedThread = null;
                    if (waitingForReadLock > 0)
                    {
                        Monitor.PulseAll(this);
                    }
                    else if (waitingForWriteLock.Count > 0)
                    {
                        writeLockedThread = waitingForWriteLock[0];
                        lock (o)
                        {
                            Monitor.PulseAll(o);
                        }
                    }
                }
                else if (waitingForReadLock > 0)
                {
                    waitingForReadLock--;
                    if (waitingForReadLock == 0 && waitingForWriteLock.Count > 0)
                    {
                        writeLockedThread = waitingForWriteLock[0];
                        lock (o)
                        {
                            Monitor.PulseAll(o);
                        }
                    }
                }
                else
                {
                    String msg = "Thread does not have lock";
                }
            }
        }
    }
}
