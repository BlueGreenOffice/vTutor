export class Tutor {
	id: string;
	name: string;
	email: string;
	subjects: TutorSubject[];
}

export class TutorSubject {
	Subject: Subject;
	Grade: Grade;
}

export enum Grade {
	Sixth = 6,
	Seventh = 7,
	Eighth = 8,
	Ninth = 9,
	Tenth = 10,
	Eleventh = 11,
	Twelfth = 12
}


export enum Subject {
	Math,
	English,
	Spanish,
	French,
	Statistics,
	Calculus,
	Trigonometry,
	Geometry,
	Algebra,
	Algebra2
}
