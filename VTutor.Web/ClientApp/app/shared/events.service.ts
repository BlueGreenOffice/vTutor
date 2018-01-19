import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Event } from '../models/Event';


@Injectable()
export class EventsService {
    constructor(private http:Http) {

	}

	private getMockedEvents(): Event[] {
		return [];
	}

	public AddAvailableBlock(event:Event) {
		return this.http.post('/api/scheduleBlocks', event);
	}

	public DeleteAvailableBlock(event: Event) {
		return this.http.delete(`/api/scheduleBlocks/${event.id}`);
	}

	public GetAvailableBlocks() {
		return this.http.get('/api/scheduleBlocks').map(response => {
			let events = <any[]>response.json();
			return events.map(x => {
				return { startTime: new Date(x.startTime), endTime: new Date(x.endTime), id: x.id };
			})
		});
	}

	public GetAllowedTimeSlots(date: Date) {

		//Monday - Thursday 4:30PM, 6PM, 7:30PM, 9PM 
		if (date.getDay() == 1
			|| date.getDay() == 2
			|| date.getDay() == 3
			|| date.getDay() == 4) {
			return [
				new Date(date.getFullYear(), date.getMonth(), date.getDate(), 16, 30),
				new Date(date.getFullYear(), date.getMonth(), date.getDate(), 18),
				new Date(date.getFullYear(), date.getMonth(), date.getDate(), 19, 30),
				new Date(date.getFullYear(), date.getMonth(), date.getDate(), 21)
			]
		}
		//Saturday 11:00AM, 12:30PM, 2:00PM
		else if (date.getDay() == 6) {
			return [
				new Date(date.getFullYear(), date.getMonth(), date.getDate(), 11),
				new Date(date.getFullYear(), date.getMonth(), date.getDate(), 12, 30),
				new Date(date.getFullYear(), date.getMonth(), date.getDate(), 14),
			]
		}
		//no other slots
		else {
			return [];
		}

		
	}

	///Gets all the events for the logged in user.
	public GetEvents() {

		return this.getMockedEvents();

	}

}
