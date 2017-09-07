#include<iostream>
#include<concrt.h>


int main()
{
	concurrency::reader_writer_lock().lock();
	concurrency::reader_writer_lock().lock_read();
	concurrency::reader_writer_lock().unlock();
	concurrency::reader_writer_lock().try_lock();
	concurrency::reader_writer_lock().try_lock_read();
	concurrency::reader_writer_lock().~reader_writer_lock();
}