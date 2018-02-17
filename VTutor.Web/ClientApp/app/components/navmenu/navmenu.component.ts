import { Component } from '@angular/core';
import { LoginService } from '../../shared/login.service';


@Component({
	selector: 'vt-nav-menu',
	templateUrl: './navmenu.component.html',
	styleUrls: ['./navmenu.component.scss']
})
export class NavMenuComponent {

	constructor(private loginService: LoginService) {

	}

	ngOnInit() {
	}


	logout() {
		this.loginService.Logout();
	}

	isLoggedIn() {
		return this.loginService.IsLoggedIn();
	}
}
