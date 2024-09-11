import { Routes } from "@angular/router";
import { HomeComponent } from "./home.component";
import { homedir } from "os";


export const HOME_ROUTES: Routes = [
    {
        path: '', component: HomeComponent, children:[]
    }
]
