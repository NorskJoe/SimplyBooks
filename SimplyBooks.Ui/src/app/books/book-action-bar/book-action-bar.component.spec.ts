import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BookActionBarComponent } from './book-action-bar.component';

describe('BookActionBarComponent', () => {
  let component: BookActionBarComponent;
  let fixture: ComponentFixture<BookActionBarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BookActionBarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BookActionBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
