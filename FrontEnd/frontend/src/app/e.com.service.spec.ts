import { TestBed } from '@angular/core/testing';

import { EComService } from './e.com.service';

describe('EComService', () => {
  let service: EComService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EComService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
