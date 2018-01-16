import { Injectable } from '@angular/core';
import { Grade, Subject, TutorSubject } from '../models/Tutor';

@Injectable()
export class SubjectsService {

	constructor() {


	}

	//Hard coded set of values based on whats available
	//someday this may hit the database.
	public GetAllAvailableSubjects() : TutorSubject[] {
		return [
			//grade six...
			{ Grade: Grade.Sixth, Subject: Subject.English },
			{ Grade: Grade.Sixth, Subject: Subject.Spanish },
			{ Grade: Grade.Sixth, Subject: Subject.French },
			{ Grade: Grade.Sixth, Subject: Subject.Math },
			//grade seven
			{ Grade: Grade.Seventh, Subject: Subject.English },
			{ Grade: Grade.Seventh, Subject: Subject.Spanish },
			{ Grade: Grade.Seventh, Subject: Subject.French },
			{ Grade: Grade.Seventh, Subject: Subject.Math },
			//grade eight
			{ Grade: Grade.Eighth, Subject: Subject.English },
			{ Grade: Grade.Eighth, Subject: Subject.Spanish },
			{ Grade: Grade.Eighth, Subject: Subject.French },
			{ Grade: Grade.Eighth, Subject: Subject.Math },
			//grade nine
			{ Grade: Grade.Ninth, Subject: Subject.Statistics },
			{ Grade: Grade.Ninth, Subject: Subject.Calculus },
			{ Grade: Grade.Ninth, Subject: Subject.Trigonometry },
			{ Grade: Grade.Ninth, Subject: Subject.Geometry },
			{ Grade: Grade.Ninth, Subject: Subject.Algebra },
			{ Grade: Grade.Ninth, Subject: Subject.Algebra2 },
			{ Grade: Grade.Ninth, Subject: Subject.English },
			{ Grade: Grade.Ninth, Subject: Subject.Spanish },
			{ Grade: Grade.Ninth, Subject: Subject.French },
			{ Grade: Grade.Ninth, Subject: Subject.Math },
			//grade ten
			{ Grade: Grade.Tenth, Subject: Subject.Statistics },
			{ Grade: Grade.Tenth, Subject: Subject.Calculus },
			{ Grade: Grade.Tenth, Subject: Subject.Trigonometry },
			{ Grade: Grade.Tenth, Subject: Subject.Geometry },
			{ Grade: Grade.Tenth, Subject: Subject.Algebra },
			{ Grade: Grade.Tenth, Subject: Subject.Algebra2 },
			{ Grade: Grade.Tenth, Subject: Subject.English },
			{ Grade: Grade.Tenth, Subject: Subject.Spanish },
			{ Grade: Grade.Tenth, Subject: Subject.French },
			{ Grade: Grade.Tenth, Subject: Subject.Math },

			//grade eleven
			{ Grade: Grade.Eleventh, Subject: Subject.Statistics },
			{ Grade: Grade.Eleventh, Subject: Subject.Calculus },
			{ Grade: Grade.Eleventh, Subject: Subject.Trigonometry },
			{ Grade: Grade.Eleventh, Subject: Subject.Geometry },
			{ Grade: Grade.Eleventh, Subject: Subject.Algebra },
			{ Grade: Grade.Eleventh, Subject: Subject.Algebra2 },
			{ Grade: Grade.Eleventh, Subject: Subject.English },
			{ Grade: Grade.Eleventh, Subject: Subject.Spanish },
			{ Grade: Grade.Eleventh, Subject: Subject.French },
			{ Grade: Grade.Eleventh, Subject: Subject.Math },

			//grade twelve
			{ Grade: Grade.Twelfth, Subject: Subject.Statistics },
			{ Grade: Grade.Twelfth, Subject: Subject.Calculus },
			{ Grade: Grade.Twelfth, Subject: Subject.Trigonometry },
			{ Grade: Grade.Twelfth, Subject: Subject.Geometry },
			{ Grade: Grade.Twelfth, Subject: Subject.Algebra },
			{ Grade: Grade.Twelfth, Subject: Subject.Algebra2 },
			{ Grade: Grade.Twelfth, Subject: Subject.English },
			{ Grade: Grade.Twelfth, Subject: Subject.Spanish },
			{ Grade: Grade.Twelfth, Subject: Subject.French },
			{ Grade: Grade.Twelfth, Subject: Subject.Math }
		];
	}






}
