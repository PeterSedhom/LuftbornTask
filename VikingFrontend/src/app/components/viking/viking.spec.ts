import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Viking } from './viking';

describe('Viking', () => {
  let component: Viking;
  let fixture: ComponentFixture<Viking>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Viking]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Viking);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
