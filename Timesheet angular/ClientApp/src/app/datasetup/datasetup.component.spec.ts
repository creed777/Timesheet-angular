import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DatasetupComponent } from './datasetup.component';

describe('DatasetupComponent', () => {
  let component: DatasetupComponent;
  let fixture: ComponentFixture<DatasetupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DatasetupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DatasetupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
