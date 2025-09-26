
# Mini Fitness Tracker 🏋️‍♂️

## 📌 الفكرة

مشروع كونسول أبليكيشن بلغة **C#** لتتبع اللياقة البدنية، بيساعد المستخدم يعمل حساب شخصي، يسجل التمارين، يحسب معدل كتلة الجسم (BMI)، يحدد أهداف للوزن، ويشوف تقدمه الأسبوعي.

---

## ⚙️ المتطلبات (Prerequisites)

* تثبيت **.NET SDK (Core أو Framework)**.
* بيئة تشغيل زي:

  * **Visual Studio** أو **Visual Studio Code**.
* نظام تشغيل Windows / Linux / Mac.

---

## 🚀 خطوات التشغيل

1. كلّون (Clone) المشروع:

   ```bash
   git clone <repo-link>
   ```
2. ادخل على فولدر المشروع:

   ```bash
   cd MiniFitnessTracker
   ```
3. شغّل البرنامج:

   ```bash
   dotnet run
   ```

---

## 📂 بنية المشروع (Structure)

```
MiniFitnessTracker/
│
├── Program.cs            # نقطة البداية - القوائم الأساسية وواجهة المستخدم
├── User.cs               # تعريف المستخدم + حساب BMI + الأهداف
├── FitnessAppEngine.cs   # المحرك الأساسي - تسجيل/تسجيل دخول - إدارة المستخدمين
├── WorkoutPlan.cs        # خطة التمارين وحساب السعرات
├── Exercise.cs           # كلاس التمارين
├── WorkoutCategory.cs    # أنواع التمارين (Cardio, Strength,...)
├── WorkoutRepository.cs  # مكتبة التمارين الجاهزة
├── ProgressTracker.cs    # متابعة التقدم الأسبوعي
├── Data_Manager.cs       # حفظ واسترجاع بيانات المستخدمين (txt file)
└── ExceptionHandling.cs  # التحقق من الإدخالات
```

---

## 🖥️ أمثلة استخدام (Usage/Examples)

### تسجيل مستخدم جديد

```
Enter name: Ahmed
Enter age: 22
Enter weight: 70
Enter height (cm): 175
Registration successful!
```

### حساب BMI

```
Your BMI is 22.86 (Normal)
```

### تعيين هدف وزن

```
Enter your target weight (kg): 65
Goal set: 65 kg
You need to lose 5.0 kg to reach your goal.
```

### تسجيل تمرين

```
=== Log Workout Menu ===
1. Cardio
2. Strength
3. Yoga
...
Choose a workout category: 1
You chose Cardio. Available exercises:
1. Running
2. Cycling
3. Jump Rope
Choose exercise: 1
You logged: Running (Cardio)
Enter duration in minutes: 30
Workout saved!
```

---

## ✨ Features

* 👤 **إدارة المستخدمين** (تسجيل / تسجيل دخول / حفظ البيانات).
* 📊 **حساب BMI** وتصنيف الوزن.
* 🎯 **تعيين هدف وزن** ومتابعة التقدم.
* 🏃 **تسجيل تمارين** بأنواع مختلفة (Cardio, Strength, Yoga, …).
* 🔥 **متابعة السعرات المحروقة** بشكل أسبوعي.
* 💾 **حفظ البيانات** في ملف نصي واسترجاعها عند تشغيل البرنامج.

---

## 📌 TODO (تطوير مستقبلي)

* إضافة **قاعدة بيانات SQL** بدلًا من الملف النصي.
* دعم **جداول غذائية** بجانب التمارين.
* إنشاء **واجهة رسومية (GUI)** بدل الكونسول.
* إضافة **تتبع تقدم يومي/شهري** بالتفصيل.
* دعم **Export/Import** للبيانات بتنسيقات (CSV / JSON).

---

## **Contributors**

- Hager Abdelbaset
- Aml Osman
- Malak Mamdouh
- Malak Abdelrahim
- Sohila Metwally
