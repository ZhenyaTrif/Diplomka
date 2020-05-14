import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdvertisingCategoryComponent } from './advertising-category.component';

describe('AdvertisingCategoryComponent', () => {
  let component: AdvertisingCategoryComponent;
  let fixture: ComponentFixture<AdvertisingCategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdvertisingCategoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdvertisingCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
