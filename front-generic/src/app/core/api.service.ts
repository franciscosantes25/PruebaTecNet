import { enviroment } from "../enviroment/enviroment";
import { Observable } from "rxjs";
import { Employee } from "../models/employee";
import { State } from "../models/state";
import { Position } from "../models/position";
import { HttpClient} from '@angular/common/http';
import { Injectable } from "@angular/core";
import { of } from 'rxjs';

@Injectable({
    providedIn: 'root',
  })
export class ApiService {
    private _apiUrl = enviroment.appUrl

    constructor(private _httpClient: HttpClient) {
    }

    // employees
    getEmployees(): Observable<Employee[]> {
        return this._httpClient.get<Employee[]>(this._apiUrl + 'employee/getEmployeeAll')
    }

    saveEmployee(employee: Employee): Observable<Employee> {
        return this._httpClient.post<Employee>(this._apiUrl + 'employee/saveEmployee', employee)
    }

    updateEmployee(employee: Employee): Observable<Employee> {
        return this._httpClient.post<Employee>(this._apiUrl + 'employee/updateEmployee', employee)
    }

    deleteEmployee(employee: Employee): Observable<Employee> {
        return this._httpClient.post<Employee>(this._apiUrl + 'employee/deleteEmployee', employee)
    }

    // states
    getStateAll(): Observable<State[]> {
        // return this._httpClient.get<State[]>(this._apiUrl + 'state/getStateAll')
        const states$ = of([{id : 1, name : 'Aguascalientes'}, {id : 2, name : 'Baja California'}]);
        return states$ 
    }

    saveState(employee: State): Observable<State> {
        return this._httpClient.post<State>(this._apiUrl + 'state/saveState', employee)
    }

    updateState(employee: State): Observable<State> {
        return this._httpClient.post<State>(this._apiUrl + 'state/updateState', employee)
    }

    deleteState(employee: State): Observable<State> {
        return this._httpClient.post<State>(this._apiUrl + 'state/deleteState', employee)
    }

    // positions
    getPositionAll(): Observable<Position[]> {
        // return this._httpClient.get<Position[]>(this._apiUrl + 'position/getPositionAll')
        const positions$ = of([{id : 1, name : 'TI'}, {id : 2, name : 'Finanzas'}]);
        return positions$ 
    }
 
    savePosition(employee: Position): Observable<Position> {
        return this._httpClient.post<Position>(this._apiUrl + 'position/savePosition', employee)
    }

    updatePosition(employee: Position): Observable<Position> {
        return this._httpClient.post<Position>(this._apiUrl + 'position/updatePosition', employee)
    }

    deletePosition(employee: Position): Observable<Position> {
        return this._httpClient.post<Position>(this._apiUrl + 'position/deletePosition', employee)
    }

}