from counter import Counter


class Clock:
    def __init__(self):
        self._seconds = Counter("seconds")
        self._minutes = Counter("minutes")
        self._hours = Counter("hours")

    def tick(self):
        self._seconds.increment()
        if self._seconds.ticks != 60:
            return

        self._seconds.reset()
        self._minutes.increment()
        if self._minutes.ticks != 60:
            return

        self._minutes.reset()
        self._hours.increment()
        if self._hours.ticks != 24:
            return

        self._hours.reset()

    def reset(self):
        self._seconds.reset()
        self._minutes.reset()
        self._hours.reset()

    @property
    def time(self):
        return (
            f"{self._hours.ticks:02}:{self._minutes.ticks:02}:{self._seconds.ticks:02}"
        )
