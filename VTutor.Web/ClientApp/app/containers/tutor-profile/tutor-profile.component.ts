import { Component } from '@angular/core';
import { Tutor } from '../../models/Tutor';

@Component({
	selector: 'vt-tutor-profile',
	templateUrl: './tutor-profile.component.html',
	styleUrls: ['tutor-profile.component.scss']
})
export class TutorProfileComponent {

	public tutor: Tutor;

	constructor() {

	}


	ngOnInit() {

	}

}
