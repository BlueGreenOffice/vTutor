import { Component } from '@angular/core';
import { LoginService } from '../../shared/login.service';

@Component({
    selector: 'vt-nav-menu',
    templateUrl: './navmenu.component.html',
    styleUrls: ['./navmenu.component.scss']
})
export class NavMenuComponent {

	public loggedIn: boolean;
	constructor(private loginService: LoginService) {

	}

	ngOnInit() {
		this.loggedIn = this.loginService.Role != null;
	}


}
