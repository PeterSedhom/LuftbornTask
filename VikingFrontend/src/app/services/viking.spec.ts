import { TestBed } from '@angular/core/testing';

import { Viking } from './viking';

describe('Viking', () => {
  let service: Viking;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(Viking);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
