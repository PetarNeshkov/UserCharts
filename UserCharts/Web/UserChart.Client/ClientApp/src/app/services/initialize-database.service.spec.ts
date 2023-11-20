import { TestBed } from '@angular/core/testing';

import { InitializeDatabaseService } from './initialize-database.service';

describe('InitializeDatabaseService', () => {
  let service: InitializeDatabaseService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InitializeDatabaseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
