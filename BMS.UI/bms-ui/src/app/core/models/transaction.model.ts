export interface Transaction {
  id:string;
  bookCode: string;
  studentId: string;
  issuedDate: Date | null;
  returnedDate: Date | null;
  expectedReturnedDate: Date | null;
}
