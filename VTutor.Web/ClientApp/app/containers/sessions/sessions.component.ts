import { Component } from '@angular/core';

@Component({
    selector: 'vt-sessions',
    templateUrl: './sessions.component.html',
    styleUrls: ['sessions.component.scss']
})
export class SessionsComponent {

	public gradeDisplay: string;
	public grade: number;

	public subjectDisplay: string;
	public subject: string;

	constructor() {

	}

	ngOnInit() {
		this.gradeDisplay = 'Select Your Grade';
		this.subjectDisplay = 'Choose Your Subject';
	}

	selectGrade(grade: number) {
		this.gradeDisplay = grade.toString();
		this.grade = grade;
	}

	selectSubject(subject: string) {
		this.subjectDisplay = subject;
		this.subject = subject;
	}

	submit() {

	}


}
