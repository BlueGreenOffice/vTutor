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
			{ SubjectGrade: { Name: Grade.Sixth }, Name: Subject.English },
			{ SubjectGrade: { Name: Grade.Sixth }, Name: Subject.Spanish },
			{ SubjectGrade: { Name: Grade.Sixth }, Name: Subject.French },
			{ SubjectGrade: { Name: Grade.Sixth }, Name: Subject.Math },
			//grade seven
			{ SubjectGrade: { Name: Grade.Seventh }, Name: Subject.English },
			{ SubjectGrade: { Name: Grade.Seventh }, Name: Subject.Spanish },
			{ SubjectGrade: { Name: Grade.Seventh }, Name: Subject.French },
			{ SubjectGrade: { Name: Grade.Seventh }, Name: Subject.Math },
			//grade eight
			{ SubjectGrade: { Name: Grade.Eighth }, Name: Subject.English },
			{ SubjectGrade: { Name: Grade.Eighth }, Name: Subject.Spanish },
			{ SubjectGrade: { Name: Grade.Eighth }, Name: Subject.French },
			{ SubjectGrade: { Name: Grade.Eighth }, Name: Subject.Math },
			//grade nine
			{ SubjectGrade: { Name: Grade.Ninth }, Name: Subject.Statistics },
			{ SubjectGrade: { Name: Grade.Ninth }, Name: Subject.Calculus },
			{ SubjectGrade: { Name: Grade.Ninth }, Name: Subject.Trigonometry },
			{ SubjectGrade: { Name: Grade.Ninth }, Name: Subject.Geometry },
			{ SubjectGrade: { Name: Grade.Ninth }, Name: Subject.Algebra },
			{ SubjectGrade: { Name: Grade.Ninth }, Name: Subject.Algebra2 },
			{ SubjectGrade: { Name: Grade.Ninth }, Name: Subject.English },
			{ SubjectGrade: { Name: Grade.Ninth }, Name: Subject.Spanish },
			{ SubjectGrade: { Name: Grade.Ninth }, Name: Subject.French },
			{ SubjectGrade: { Name: Grade.Ninth }, Name: Subject.Math },
			//grade ten
			{ SubjectGrade: { Name: Grade.Tenth }, Name: Subject.Statistics },
			{ SubjectGrade: { Name: Grade.Tenth }, Name: Subject.Calculus },
			{ SubjectGrade: { Name: Grade.Tenth }, Name: Subject.Trigonometry },
			{ SubjectGrade: { Name: Grade.Tenth }, Name: Subject.Geometry },
			{ SubjectGrade: { Name: Grade.Tenth }, Name: Subject.Algebra },
			{ SubjectGrade: { Name: Grade.Tenth }, Name: Subject.Algebra2 },
			{ SubjectGrade: { Name: Grade.Tenth }, Name: Subject.English },
			{ SubjectGrade: { Name: Grade.Tenth }, Name: Subject.Spanish },
			{ SubjectGrade: { Name: Grade.Tenth }, Name: Subject.French },
			{ SubjectGrade: { Name: Grade.Tenth }, Name: Subject.Math },

			//grade eleven
			{ SubjectGrade: { Name: Grade.Eleventh }, Name: Subject.Statistics },
			{ SubjectGrade: { Name: Grade.Eleventh }, Name: Subject.Calculus },
			{ SubjectGrade: { Name: Grade.Eleventh }, Name: Subject.Trigonometry },
			{ SubjectGrade: { Name: Grade.Eleventh }, Name: Subject.Geometry },
			{ SubjectGrade: { Name: Grade.Eleventh }, Name: Subject.Algebra },
			{ SubjectGrade: { Name: Grade.Eleventh }, Name: Subject.Algebra2 },
			{ SubjectGrade: { Name: Grade.Eleventh }, Name: Subject.English },
			{ SubjectGrade: { Name: Grade.Eleventh }, Name: Subject.Spanish },
			{ SubjectGrade: { Name: Grade.Eleventh }, Name: Subject.French },
			{ SubjectGrade: { Name: Grade.Eleventh }, Name: Subject.Math },

			//grade twelve
			{ SubjectGrade: { Name: Grade.Twelfth }, Name: Subject.Statistics },
			{ SubjectGrade: { Name: Grade.Twelfth }, Name: Subject.Calculus },
			{ SubjectGrade: { Name: Grade.Twelfth }, Name: Subject.Trigonometry },
			{ SubjectGrade: { Name: Grade.Twelfth }, Name: Subject.Geometry },
			{ SubjectGrade: { Name: Grade.Twelfth }, Name: Subject.Algebra },
			{ SubjectGrade: { Name: Grade.Twelfth }, Name: Subject.Algebra2 },
			{ SubjectGrade: { Name: Grade.Twelfth }, Name: Subject.English },
			{ SubjectGrade: { Name: Grade.Twelfth }, Name: Subject.Spanish },
			{ SubjectGrade: { Name: Grade.Twelfth }, Name: Subject.French },
			{ SubjectGrade: { Name: Grade.Twelfth }, Name: Subject.Math }
		];
	}






}
