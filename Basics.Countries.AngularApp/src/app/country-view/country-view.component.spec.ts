import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CountryViewComponent } from './country-view.component';

describe('CountryViewComponent', () => {
  let component: CountryViewComponent;
  let fixture: ComponentFixture<CountryViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CountryViewComponent]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CountryViewComponent);
    component = fixture.componentInstance;
    component.country = {
      id: 'id01',
      alpha2Code: '2Code',
      alpha3Code: '3code',
      latitude: 'lat',
      longitude: 'long',
      name: 'Name',
      officialName: 'OffName',
      statusType: 1,
      zoom: 4,
    }
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should display country details', () => {
    fixture.detectChanges();
    const h1 = fixture.nativeElement.querySelector('#idCountryName');
    expect(h1.innerText).toEqual("Name");
    expect(fixture.nativeElement.querySelector('#idOfficialName').innerText).toEqual("OffName");
    expect(fixture.nativeElement.querySelector('#idAlpha2Code').innerText).toEqual("2Code");
    expect(fixture.nativeElement.querySelector('#idAlpha3Code').innerText).toEqual("3code");
    expect(fixture.nativeElement.querySelector('#idLatitude').innerText).toEqual("lat");
    expect(fixture.nativeElement.querySelector('#idLongitude').innerText).toEqual("long");
  });
});
