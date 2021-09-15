import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccounthomepageComponent } from './accounthomepage.component';

describe('AccounthomepageComponent', () => {
  let component: AccounthomepageComponent;
  let fixture: ComponentFixture<AccounthomepageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccounthomepageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccounthomepageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
