using System;

namespace Pharmacy
{
    class Routing
    {
        int customerID;
        string medicineName;
        int how; //int how - if not selected 0, if with meals 1, if per hours 2, if at a time 3
        int breakfast;
        int lunch;
        int dinner;
        int beforeOrAfter;//if not checked 0, if before 1, if after 2
        int hours;
        int times;
        DateTime? time;


        public Routing(int customerID, string medicineName, int how, int breakfast, int lunch, int dinner, int beforeOrAfter, int hours, int times, DateTime? time)
        {
            this.customerID = customerID;
            this.medicineName = medicineName;
            this.how = how;
            this.breakfast = breakfast;
            this.lunch = lunch;
            this.dinner = dinner;
            this.beforeOrAfter = beforeOrAfter;
            this.hours = hours;
            this.times = times;
            this.time = time;
        }

        public int getCustomerID() { return customerID; }
        public void setCustomerID(int customerID) { this.customerID = customerID; }
        public string getMedicineName() { return medicineName; }
        public void setMedicineName(string medicineName) { this.medicineName = medicineName; }
        public int getHow() { return how; }
        public void setHow(int how) { this.how = how; }
        public int getBreakfast() { return breakfast; }
        public void setBreakfast(int breakfast) { this.breakfast = breakfast; }
        public int getLunch() { return lunch; }
        public void setLunch(int lunch) { this.lunch = lunch; }
        public int getDinner() { return dinner; }
        public void setDinner(int dinner) { this.dinner = dinner; }
        public int getBeforeOrAfter() { return beforeOrAfter; }
        public void setBeforeOrAfter(int BeforeOrAfter) { this.beforeOrAfter = BeforeOrAfter; }
        public int getHours() { return hours; }
        public void setHours(int hours) { this.hours = hours; }
        public int getTimes() { return times; }
        public void setTimes(int times) { this.times = times; }
        public DateTime? getTime() { return time; }
        public void setTime(DateTime? time) { this.time = time; }



    }
}
