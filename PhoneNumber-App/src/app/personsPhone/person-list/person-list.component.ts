import { Component, OnInit } from '@angular/core';
import { Person } from '../person';
import { PersonsPhoneService } from '../personsPhone.service';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html'
})
export class PersonListComponent implements OnInit {

  constructor(private personService: PersonsPhoneService) { }

  public persons: Person[];

  ngOnInit() {
    this.personService.getPersons().subscribe(
      persons => {
        this.persons = persons;
      }
    );
  }
}
