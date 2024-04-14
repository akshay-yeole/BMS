export interface Transaction {
  bookCode: string;
  studentId: string;
  issuedDate: Date | null;
  returnedDate: Date | null;
  expectedReturnedDate: Date | null;
}
