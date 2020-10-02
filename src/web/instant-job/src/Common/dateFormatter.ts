export function formatDate(date: Date) {
  return `${new Date(date).toLocaleDateString("pl-PL")} ${new Date(date).toLocaleTimeString("pl-PL")}`;
}

export function formatDateShort(date: Date) {
  return `${new Date(date).toLocaleDateString("pl-PL")}`;
}

export function getFormattedTimeLeft(date: Date): TimeLeft {
  let now = getNowUTCDate();
  if (date <= now) {
    return { count: 0, type: "minutes" };
  }
  let minutesDifference = (new Date(date).getTime() - now.getTime()) / 60000;
  // less than an hour
  if (minutesDifference < 60) {
    return { count: Math.round(minutesDifference), type: "minutes" };
  }
  // less than a day
  if (minutesDifference < 1440) {
    return { count: Math.round(minutesDifference / 60), type: "hours" };
  }
  // less than a month
  if (minutesDifference < 43200) {
    return { count: Math.round(minutesDifference / (60 * 24)), type: "days" };
  }
  return { count: Math.round(minutesDifference / (60 * 24 * 30)), type: "months" };
}

export interface TimeLeft {
  count: number;
  type: "minutes" | "hours" | "days" | "months";
}

export function getNowUTCDate() {
  return new Date(
    new Date().getUTCFullYear(),
    new Date().getUTCMonth(),
    new Date().getUTCDate(),
    new Date().getUTCHours(),
    new Date().getUTCMinutes(),
    new Date().getUTCSeconds()
  );
}
