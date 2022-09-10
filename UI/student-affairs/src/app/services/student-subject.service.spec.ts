import { TestBed } from '@angular/core/testing';

import { StudentSubjectService } from './student-subject.service';

describe('StudentSubjectService', () => {
  let service: StudentSubjectService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StudentSubjectService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
