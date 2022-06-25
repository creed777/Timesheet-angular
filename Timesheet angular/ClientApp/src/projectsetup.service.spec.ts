import { TestBed } from '@angular/core/testing';

import { ProjectsetupService } from './projectsetup.service';

describe('ProjectsetupService', () => {
  let service: ProjectsetupService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProjectsetupService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
