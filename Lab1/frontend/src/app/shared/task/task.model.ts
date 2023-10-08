import { DatePipe } from "@angular/common"

export class Task {
    id: number = 0
    name: string = ''
    description: string = ''
    creationDate: string = ''
    lastUpdate: string = ''
    deadline: string | null
    taskStatus: string = ''
    taskStatusId: number = 1
    taskPriority: string = ''
    taskPriorityId: number = 1
    projectId: number = 0
    userId: any = null

    constructor(){
        const datePipe = new DatePipe('en-US');
        let date = new Date();

        this.deadline =  datePipe.transform(date, 'yyyy-MM-dd');
    }
}
