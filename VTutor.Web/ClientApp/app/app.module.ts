import { NgModule, Inject } from '@angular/core';
import { RouterModule, PreloadAllModules } from '@angular/router';
import { CommonModule, APP_BASE_HREF } from '@angular/common';
import { HttpModule, Http } from '@angular/http';
import { FormsModule } from '@angular/forms';

//External Components
import { BsDropdownModule, CarouselModule } from 'ngx-bootstrap';
import { TagInputModule } from 'ngx-chips';
//import { CalendarModule } from 'primeng/primeng';


// i18n support
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

import { AppComponent } from './app.component';

//Components
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { CalendarComponent } from './components/calendar/calendar.component';
import { FooterComponent } from './components/footer/footer.component';

//Pages
import { HomeComponent } from './containers/home/home.component';
import { StudentRegisterComponent } from './containers/student-register/student-register.component';
import { ReferAFriendComponent } from './containers/refer-a-friend/refer-a-friend.component';
import { WhyVtutorComponent } from './containers/why-vtutor/why-vtutor.component';
import { BecomeVTutor } from './containers/become-vtutor/become-vtutor.component';
import { LoginComponent } from './containers/login/login.component';
import { SessionsComponent } from './containers/sessions/sessions.component';
import { DashboardComponent } from './containers/dashboard/dashboard.component';
import { AdminDashboardComponent } from './containers/admin-dashboard/admin-dashboard.component';
import { NotFoundComponent } from './containers/not-found/not-found.component';

import { LinkService } from './shared/link.service';
import { UserService } from './shared/user.service';
import { TutorsService } from './shared/tutors.service';
import { SubjectsService } from './shared/subjects.service';
import { EventsService } from './shared/events.service';
import { LoginService } from './shared/login.service';
import { AdminService } from './shared/admin.service';

import { ORIGIN_URL } from './shared/constants/baseurl.constants';
import { TransferHttpModule } from '../modules/transfer-http/transfer-http.module';

export function createTranslateLoader(http: Http, baseHref) {
	// Temporary Azure hack
	if (baseHref === null && typeof window !== 'undefined') {
		baseHref = window.location.origin;
	}
	// i18n files are in `wwwroot/assets/`
	return new TranslateHttpLoader(http, `${baseHref}/assets/i18n/`, '.json');
}

@NgModule({
	declarations: [
		AppComponent,

		//Components
		NavMenuComponent,
		CalendarComponent,
		FooterComponent,

		//Pages
		StudentRegisterComponent,
		SessionsComponent,
		ReferAFriendComponent,
		HomeComponent,
		WhyVtutorComponent,
		DashboardComponent,
		AdminDashboardComponent,
		BecomeVTutor,
		LoginComponent,
		NotFoundComponent,
	],
	imports: [
		CommonModule,
		HttpModule,
		FormsModule,

		//CalendarModule,
		TagInputModule,
		BsDropdownModule.forRoot(),
		CarouselModule.forRoot(),

		TransferHttpModule, // Our Http TransferData method

		// i18n support
		TranslateModule.forRoot({
			loader: {
				provide: TranslateLoader,
				useFactory: (createTranslateLoader),
				deps: [Http, [ORIGIN_URL]]
			}
		}),

		// App Routing
		RouterModule.forRoot([
			{
				path: '',
				redirectTo: 'home',
				pathMatch: 'full'
			},
			{
				path: 'home', component: HomeComponent,

				// *** SEO Magic ***
				// We're using "data" in our Routes to pass in our <title> <meta> <link> tag information
				// Note: This is only happening for ROOT level Routes, you'd have to add some additional logic if you wanted this for Child level routing
				// When you change Routes it will automatically append these to your document for you on the Server-side
				//  - check out app.component.ts to see how it's doing this
				data: {
					title: 'Homepage',
					meta: [{ name: 'description', content: 'This is an example Description Meta tag!' }],
					links: [
						{ rel: 'canonical', href: 'http://blogs.example.com/blah/nice' },
						{ rel: 'alternate', hreflang: 'es', href: 'http://es.example.com/' }
					]
				}
			},

			{
				path: 'why-vtutor', component: WhyVtutorComponent,
				data: {
					title: 'Why vTutor',
					meta: [{}],
					links: [

					]
				}
			},

			{
				path: 'dashboard', component: DashboardComponent,
				data: {
					title: 'Dashboard',
					meta: [{}],
					links: [
					]
				}
			},

			{
				path: 'admin-dashboard', component: AdminDashboardComponent,
				data: {
					title: 'Administrator Dashboard',
					meta: [{}],
					links: [
					]
				}
			},

			{
				path: 'tutor-register', component: BecomeVTutor,
				data: {
					title: 'Become A vTutor',
					meta: [{}],
					links: [

					]
				}
			},
			{
				path: 'student-register', component: StudentRegisterComponent,
				data: {
					title: 'Sessions',
					meta: [{}],
					links: [
					]
				}
			},
			{
				path: 'login', component: LoginComponent,
				data: {
					title: 'Login',
					meta: [{}],
					links: [
					]
				}
			},

			{
				path: 'sessions', component: SessionsComponent,
				data: {
					title: 'Sessions',
					meta: [{}],
					links: [
					]
				}
			},

			{
				path: 'refer-a-friend', component: ReferAFriendComponent,
				data: {
					title: 'Sessions',
					meta: [{}],
					links: [
					]
				}
			},

			{
				path: '**', component: NotFoundComponent,
				data: {
					title: '404 - Not found',
					meta: [{ name: 'description', content: '404 - Error' }],
					links: [
						{ rel: 'canonical', href: 'http://blogs.example.com/bootstrap/something' },
						{ rel: 'alternate', hreflang: 'es', href: 'http://es.example.com/bootstrap-demo' }
					]
				}
			}
		], {
				// Router options
				useHash: false,
				preloadingStrategy: PreloadAllModules,
				initialNavigation: 'enabled'
			})
	],
	providers: [
		LinkService,
		UserService,
		TutorsService,
		SubjectsService,
		EventsService,
		LoginService,
		AdminService,
		// ConnectionResolver,
		TranslateModule
	]
})
export class AppModuleShared {
}
