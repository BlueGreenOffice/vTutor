import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class AdminService {
	constructor(private http:Http) {



	}

	getUnapprovedTutors() {
		return this.http.get(`api/tutors/`).map(response => {
			return response.json();
		});
	}


}
