import { Injectable } from '@angular/core';

import { Http } from '@angular/http';


@Injectable()
export class LoginService {

	constructor(private http:Http) {
	}

	Login(username: string, password: string) {

		this.http.post(`account/login?email=${username}&password=${password}`, {}).subscribe(result => {
			//todo:
		})

	}

}
