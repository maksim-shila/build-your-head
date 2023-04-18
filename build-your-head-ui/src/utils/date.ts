export function dateNowPlus(increment: { seconds?: number, minutes?: number }): Date {
    const now = new Date();
    increment.seconds && now.setSeconds(now.getSeconds() + increment.seconds);
    increment.minutes && now.setMinutes(now.getMinutes() + increment.minutes);
    return now;
}