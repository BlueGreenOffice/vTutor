import { Injectable } from '@angular/core';

import { Student } from '../models/Student';
import { Http } from '@angular/http';


@Injectable()
export class StudentsService {

	constructor(private http: Http) {

	}


	public GetLoggedInStudent() {
		return this.http.get('api/students?current=true');
	}

	public SaveStudent(student: Student) {
		if (student.id == null) {
			return this.http.post('api/students', student);
		}
		else {
			return this.http.put('api/students/' + student.id, student);
		}
	}

}
