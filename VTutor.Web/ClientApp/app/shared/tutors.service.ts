import { Injectable } from '@angular/core';

import { Tutor } from '../models/Tutor';
import { Http } from '@angular/http';


@Injectable()
export class TutorsService {

	constructor(private http: Http) {

	}


	public SaveTutor(tutor: Tutor) {

		return this.http.post('api/tutors', tutor)
			
	}




}
