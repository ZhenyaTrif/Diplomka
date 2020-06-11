import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AuctionLotDetailsComponent } from './auction-lot-details.component';

describe('AuctionLotDetailsComponent', () => {
  let component: AuctionLotDetailsComponent;
  let fixture: ComponentFixture<AuctionLotDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AuctionLotDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AuctionLotDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
