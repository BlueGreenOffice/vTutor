import { Component, TemplateRef } from '@angular/core';
import { SubjectsService } from '../../shared/subjects.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

import { Grade, Subject, TutorSubject } from '../../models/Tutor';

@Component({
    selector: 'vt-sessions',
    templateUrl: './sessions.component.html',
    styleUrls: ['sessions.component.scss']
})
export class SessionsComponent {
	modalRef: BsModalRef;
	public grade: number;
	public subject: string;

	allGrades: Grade[];
	allSubjects: Subject[];
	subjects: TutorSubject[];

	tutorSubject: TutorSubject;

	constructor(private subjectsService: SubjectsService, private modalService: BsModalService) {

	}

	ngOnInit() {
		this.tutorSubject = new TutorSubject();

		this.subjects = this.subjectsService.GetAllAvailableSubjects();

		this.allGrades = this.subjects.map(x => x.SubjectGrade.Name).filter((e, i, s) => i == s.indexOf(e));
		this.allSubjects = this.subjects.map(x => x.Name).filter((e, i, s) => i == s.indexOf(e));
	}

	selectGrade(grade: Grade) {
		this.tutorSubject.SubjectGrade = { Name: grade };
	}

	selectSubject(subject: Subject) {
		this.tutorSubject.Name = subject;
	}

	public gradeDisplay() {
		return this.tutorSubject.SubjectGrade == null ? 'Select Your Grade' : this.tutorSubject.SubjectGrade.Name.toString();
	}

	public subjectDisplay() {
		return this.tutorSubject.Name == null ? 'Select Your Subject' : this.tutorSubject.Name.toString();
	}

	submit(template: TemplateRef<any>) {
		this.modalRef = this.modalService.show(template);
	}


}
