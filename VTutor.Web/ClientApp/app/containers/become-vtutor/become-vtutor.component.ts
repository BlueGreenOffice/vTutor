import { Component } from '@angular/core';

import { Tutor } from '../../models/Tutor';
import { TutorsService } from '../../shared/tutors.service';
import { LoginService } from '../../shared/login.service';
import { SubjectsService } from '../../shared/subjects.service';

import { Grade, Subject, TutorSubject } from '../../models/Tutor';

@Component({
    selector: 'vt-become-vtutor',
    templateUrl: './become-vtutor.component.html',
    styleUrls: ['become-vtutor.component.scss']
})
export class BecomeVTutor {

	subjects: TutorSubject[];

	tutor: Tutor;

	//these are not on the tutor object for security.
	password: string;
	confirmPassword: string;


	allGrades: Grade[];
	allSubjects: Subject[];

	constructor(private tutors: TutorsService, private loginService: LoginService, private subjectsService:SubjectsService) {
	
	}

	ngOnInit() {
		this.tutor = new Tutor();
		this.tutor.subjects = [];
		this.subjects = this.subjectsService.GetAllAvailableSubjects();

		this.tutor.subjects.push({ subjectGrade: null, name: null });
		this.allGrades = this.subjects.map(x => x.subjectGrade.name).filter((e, i, s) => i == s.indexOf(e));
		this.allSubjects = this.subjects.map(x => x.name).filter((e, i, s) => i == s.indexOf(e));
	}

	private addSubjectIfNecessary() {
		if (this.tutor.subjects.every(x => x.name != null && x.subjectGrade != null)) {
			this.tutor.subjects.push({ subjectGrade: null, name: null });
		}
	}

	public selectGrade(subject:TutorSubject, grade:Grade) {
		subject.subjectGrade = { name: grade };
		this.addSubjectIfNecessary();
	}

	public selectSubject(tutorSubject: TutorSubject, subject: Subject) {
		tutorSubject.name = subject;
		this.addSubjectIfNecessary();
	}

	public submit() {
		this.tutors.SaveTutor(this.tutor).subscribe(r => {
			this.loginService.RegisterTutor(this.tutor.email, this.password);
		});
		
	}

	public gradeDisplay(subject: TutorSubject) {
		return subject.subjectGrade == null ? 'Grade' : subject.subjectGrade.name.toString();
	}

	public subjectDisplay(subject: TutorSubject) {
		return subject.name == null ? 'Subject' : subject.name.toString();
	}

}

