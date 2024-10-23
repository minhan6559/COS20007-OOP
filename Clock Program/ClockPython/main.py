import time
import os
import psutil
from clock import Clock


def run_clock(seconds):
    clock = Clock()
    for _ in range(seconds):
        clock.tick()


def main():
    # Start the stopwatch
    start_time = time.time()

    # Run the clock for 104844794 ticks
    run_clock(104844794)

    # Stop the stopwatch
    end_time = time.time()

    print("Python Clock - Minh An Nguyen - 104844794\n")
    # Calculate elapsed time in microseconds
    elapsed_time = (end_time - start_time) * 1_000_000
    print(f"Time elapsed: {elapsed_time:,.0f} microseconds")

    # Get the current process
    process = psutil.Process(os.getpid())

    # Display the total physical memory size allocated for the current process
    print(f"Current physical memory usage: {process.memory_info().rss:,} bytes")

    # Display peak memory statistics for the process
    print(f"Peak physical memory usage: {process.memory_info().peak_wset:,} bytes")


if __name__ == "__main__":
    main()
