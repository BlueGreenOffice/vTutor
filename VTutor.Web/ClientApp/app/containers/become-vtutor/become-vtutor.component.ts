import { Component } from '@angular/core';

import { Tutor } from '../../models/Tutor';
import { TutorsService } from '../../shared/tutors.service';
import { LoginService } from '../../shared/login.service';


@Component({
    selector: 'vt-become-vtutor',
    templateUrl: './become-vtutor.component.html',
    styleUrls: ['become-vtutor.component.scss']
})
export class BecomeVTutor {

	tutor: Tutor;

	//these are not on the tutor object for security.
	password: string;
	confirmPassword: string;

	constructor(private tutors: TutorsService, private loginSerivce: LoginService) {
	
	}

	ngOnInit() {
		this.tutor = new Tutor();
	}

	public submit() {
		this.tutors.SaveTutor(this.tutor);
		this.loginSerivce.RegisterTutor(this.tutor.email, this.password);
	}


}

