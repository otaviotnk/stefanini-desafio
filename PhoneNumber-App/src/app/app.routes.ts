import { Routes } from "@angular/router";
import { HomeComponent } from "./navigation/home/home.component";
import { PersonListComponent } from "./personsPhone/person-list/person-list.component";

export const rootRouterConfig: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'person-list', component: PersonListComponent }
];