import { Component } from '@angular/core';

import { Tutor } from '../../models/Tutor';
import { TutorsService } from '../../shared/tutors.service';

@Component({
    selector: 'vt-become-vtutor',
    templateUrl: './become-vtutor.component.html',
    styleUrls: ['become-vtutor.component.scss']
})
export class BecomeVTutor {

	tutor: Tutor;

	constructor(private tutors: TutorsService) {
	
	}

	ngOnInit() {
		this.tutor = new Tutor();
	}

	public submit() {
		this.tutors.SaveTutor(this.tutor);
	}


}

