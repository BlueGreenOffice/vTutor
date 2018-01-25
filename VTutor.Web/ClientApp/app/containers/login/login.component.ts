import { Component } from '@angular/core';

import { LoginService } from '../../shared/login.service';

@Component({
    selector: 'vt-login',
    templateUrl: './login.component.html',
    styleUrls: ['login.component.scss']
})
export class LoginComponent {

	constructor(private loginService:LoginService) {

	}

	public email: string;
	public password: string;

	login() {
		this.loginService.Login(this.email, this.password);
	}

}
