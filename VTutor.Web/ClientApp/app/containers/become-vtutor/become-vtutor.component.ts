import { Component } from '@angular/core';

import { Tutor } from '../../models/Tutor';
import { TutorsService, TutorInterestEmail } from '../../shared/tutors.service';
import { LoginService } from '../../shared/login.service';
import { SubjectsService } from '../../shared/subjects.service';

import { Grade, Subject, TutorSubject } from '../../models/Tutor';

@Component({
    selector: 'vt-become-vtutor',
    templateUrl: './become-vtutor.component.html',
    styleUrls: ['become-vtutor.component.scss']
})
export class BecomeVTutor {

	tutor: TutorInterestEmail;

	constructor(private tutors: TutorsService) {
		this.tutor = new TutorInterestEmail();
	}

	public submit() {
		this.tutors.SendInterestEmail(this.tutor).subscribe(x => { /** Nothin' to see here, move along **/ });
		
	}
	

}

