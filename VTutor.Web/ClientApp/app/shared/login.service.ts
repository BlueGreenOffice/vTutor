import { Injectable, Inject } from '@angular/core';
import { Router } from '@angular/router'
import { ORIGIN_URL } from './constants/baseurl.constants';
import { Http } from '@angular/http';
import { TransferHttp } from '../../modules/transfer-http/transfer-http';

@Injectable()
export class LoginService {

	public Role: string;

	constructor(
		@Inject(ORIGIN_URL) private baseUrl: string,
		private http: Http,
		private transferHttp: TransferHttp,
		private router: Router) {

	}

	Login(username: string, password: string) {
		this.http.post(`account/login?email=${username}&password=${password}`, {}).subscribe(result => {
			this.Role = result.json()[0];
			if (this.Role == 'Tutors') {
				this.router.navigate(['dashboard']);
			}
			else if (this.Role == 'Students') {
				this.router.navigate([''])
			}
			else if (this.Role == 'Admin') {
				this.router.navigate(['admin-dashboard']);
			}
			
		})
	}
	

	RegisterTutor(username: string, password: string) {
		this.http.post(`account/register?email=${username}&password=${password}&registrationType=Tutors`, {}).subscribe(result => {
			
		})
	}

	private GetRoles() {
		this.transferHttp.get(`${this.baseUrl}/account/roles`).subscribe(result => {
			this.Role = result.json()[0];
		})
	}


}
