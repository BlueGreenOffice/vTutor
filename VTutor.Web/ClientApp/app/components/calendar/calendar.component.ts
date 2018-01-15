import { Component, Input } from '@angular/core';


import { Event } from '../../models/Event';

class Day {
    DayOfWeek: number;
    DayOfMonth: number;
    ActiveDay: boolean;
}

@Component({
    selector: 'vt-calendar',
    templateUrl: './calendar.component.html',
    styleUrls: ['./calendar.component.scss']
})
export class CalendarComponent {

    @Input()
    events: Event[];

    days: Day[];

    currentYear: number;
    currentMonth: string;
    currentDayOfMonth: number;

    constructor() {
        this.days = [];
    }

    ngOnInit() {
        let today = new Date();
        this.currentMonth = this.months[today.getMonth()];
        this.currentYear = today.getFullYear();
        this.currentDayOfMonth = today.getDate();

        for (var i = 1; i <= this.daysInMonth(today.getMonth(), today.getFullYear()); i++) {
            let dayOfMonth = new Date(today.getFullYear(), today.getMonth(), i).getDate();
            let dayOfWeek = new Date(today.getFullYear(), today.getMonth(), i).getDay();

            let isToday = dayOfMonth == today.getDate();
            this.days.push({ DayOfWeek : dayOfWeek, DayOfMonth : dayOfMonth, ActiveDay : isToday });
        }
    }

    moveToPreviousMonth() {

    }

    moveToNextMont() {

    }

    mondays() {
        return this.days.filter((x) => x.DayOfWeek == 1);
    }

    tuesdays() {
        return this.days.filter((x) => x.DayOfWeek == 2);
    }

    wednesdays() {
        return this.days.filter((x) => x.DayOfWeek == 3);
    }

    thursdays() {
        return this.days.filter((x) => x.DayOfWeek == 4);
    }

    fridays() {
        return this.days.filter((x) => x.DayOfWeek == 5);
    }

    saturdays() {
        return this.days.filter((x) => x.DayOfWeek == 6);
    }

    sundays() {
        return this.days.filter((x) => x.DayOfWeek == 0);
    }

    daysInMonth(month, year) {
      return new Date(year, month, 0).getDate();
    }



    months: string[] = [
        "JANUARY",
        "FEBRUARY",
        "MARCH",
        "APRIL",
        "MAY",
        "JUNE",
        "JULY",
        "AUGUST",
        "SEPTEMBER",
        "OCTOBER",
        "NOVEMBER",
        "DECEMBER"
    ];


}
