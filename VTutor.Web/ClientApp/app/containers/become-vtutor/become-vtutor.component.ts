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

		this.tutor.subjects.push({ SubjectGrade: null, Name: null });
		this.allGrades = this.subjects.map(x => x.SubjectGrade.Name).filter((e, i, s) => i == s.indexOf(e));
		this.allSubjects = this.subjects.map(x => x.Name).filter((e, i, s) => i == s.indexOf(e));
	}

	private addSubjectIfNecessary() {
		if (this.tutor.subjects.every(x => x.Name != null && x.SubjectGrade != null)) {
			this.tutor.subjects.push({ SubjectGrade: null, Name: null });
		}
	}

	public selectGrade(subject:TutorSubject, grade:Grade) {
		subject.SubjectGrade = { Name: grade };
		this.addSubjectIfNecessary();
	}

	public selectSubject(tutorSubject: TutorSubject, subject: Subject) {
		tutorSubject.Name = subject;
		this.addSubjectIfNecessary();
	}

	public submit() {
		this.tutors.SaveTutor(this.tutor).subscribe(r => {
			this.loginService.RegisterTutor(this.tutor.email, this.password);
		});
		
	}

	public gradeDisplay(subject: TutorSubject) {
		return subject.SubjectGrade == null ? 'Grade' : subject.SubjectGrade.Name.toString();
	}

	public subjectDisplay(subject: TutorSubject) {
		return subject.Name == null ? 'Subject' : subject.Name.toString();
	}

}

