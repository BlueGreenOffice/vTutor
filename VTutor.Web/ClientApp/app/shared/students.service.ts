import { Injectable } from '@angular/core';

import { Student } from '../models/Student';
import { Http } from '@angular/http';


@Injectable()
export class StudentsService {

	constructor(private http: Http) {

	}


	public SaveStudent(student: Student) {

		return this.http.post('api/students', student)

	}




}
