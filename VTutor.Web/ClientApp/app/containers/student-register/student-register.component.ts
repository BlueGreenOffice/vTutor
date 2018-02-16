import { Component } from '@angular/core';
import { StudentsService } from '../../shared/students.service';
import { Student } from '../../models/Student';

@Component({
    selector: 'vt-student-register',
    templateUrl: './student-register.component.html',
    styleUrls: ['student-register.component.scss']
})
export class StudentRegisterComponent {

	private student: Student;

	constructor(private studentsService: StudentsService) {
		this.student = new Student();
	}

	public submit() {
		this.studentsService.SaveStudent(this.student).subscribe(x => { /*todo:*/ });
	}
}
