import { Component, TemplateRef, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { SubjectsService } from '../../shared/subjects.service';
import { Event } from '../../models/Event';
import { EventsService } from '../../shared/events.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Grade, Subject, TutorSubject } from '../../models/Tutor';

@Component({
    selector: 'vt-sessions',
    templateUrl: './sessions.component.html',
	styleUrls: ['sessions.component.scss'],
	encapsulation: ViewEncapsulation.None //this tells angular to allow external css to apply to internal components...
})
export class SessionsComponent {
	modalRef: BsModalRef;
	public grade: number;
	public subject: string;

	allGrades: Grade[];
	allSubjects: Subject[];
	subjects: TutorSubject[];

	tutorSubject: TutorSubject;

	myForm: FormGroup;

	minDate = new Date(2017, 5, 10);
	maxDate = new Date(2018, 9, 15);

	bsValue: Date = new Date();
	bsRangeValue: any = [new Date(2017, 7, 4), new Date(2017, 7, 20)];

	form: { date: Date, range: any } = { date: null, range: null };

	blocks: Event[];

	constructor(private subjectsService: SubjectsService, private modalService: BsModalService, private formBuilder:FormBuilder, private eventsService:EventsService) {

	}

	ngOnInit() {
		this.tutorSubject = new TutorSubject();

		this.subjects = this.subjectsService.GetAllAvailableSubjects();

		this.allGrades = this.subjects.map(x => x.subjectGrade.name).filter((e, i, s) => i == s.indexOf(e));
		this.allSubjects = this.subjects.map(x => x.name).filter((e, i, s) => i == s.indexOf(e));

		this.myForm = this.formBuilder.group(this.form);
		this.myForm.valueChanges.subscribe((value) => {
			this.eventsService.GetBlocksAvailableToBook(value.date).subscribe(blocks => {
				this.blocks = blocks.filter(block => {
					return block.tutor.subjects.some(x => x.subjectGrade != null && x.subjectGrade.name.toString() == this.tutorSubject.subjectGrade.name.toString() && x.name == this.tutorSubject.name)
				});
			});
		});
	}

	selectGrade(grade: Grade) {
		this.tutorSubject.subjectGrade = { name: grade };
	}

	selectSubject(subject: Subject) {
		this.tutorSubject.name = subject;
	}

	public gradeDisplay() {
		return this.tutorSubject.subjectGrade == null ? 'Select Your Grade' : this.tutorSubject.subjectGrade.name.toString();
	}

	public subjectDisplay() {
		return this.tutorSubject.name == null ? 'Select Your Subject' : this.tutorSubject.name.toString();
	}

	submit(template: TemplateRef<any>) {
		this.modalRef = this.modalService.show(template);
	}

	selectBlock(block: Event) {
		//todo:
	}

	formatTime(date: Date) {
		if (date.getHours() < 13) {
			if (date.getMinutes() == 0) {
				return date.getHours() + ':00 AM';
			}
			else {
				return date.getHours() + ':' + date.getMinutes() + ' AM';
			}
		}
		else {
			if (date.getMinutes() == 0) {
				return (date.getHours() - 12) + ':00 PM';
			}
			else {
				return (date.getHours() - 12) + ':' + date.getMinutes() + ' PM';
			}
		}
	}

}
