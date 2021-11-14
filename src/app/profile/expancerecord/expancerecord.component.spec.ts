import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpancerecordComponent } from './expancerecord.component';

describe('ExpancerecordComponent', () => {
  let component: ExpancerecordComponent;
  let fixture: ComponentFixture<ExpancerecordComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExpancerecordComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExpancerecordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
