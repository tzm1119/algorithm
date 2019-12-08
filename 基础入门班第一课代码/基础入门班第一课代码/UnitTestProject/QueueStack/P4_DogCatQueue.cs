using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestProject.Common;

namespace UnitTestProject.QueueStack
{
    public class P4_DogCatQueue: IExecTest
    {
        Queue<PetEnterQueue> dogQ = new Queue<PetEnterQueue>();
        Queue<PetEnterQueue> catQ = new Queue<PetEnterQueue>();
        long count;
        string wronyTypeException = "pet type is not define";
        string petEmptyException = "queue is empty";

        public void AddPet(Pet pet)
        {
            if (pet.Type== PetType.Dog)
            {
                dogQ.Enqueue(new PetEnterQueue(pet, this.count++));
            }
            else if (pet.Type== PetType.Cat)
            {
                catQ.Enqueue(new PetEnterQueue(pet, this.count++));
            }
            else
            {
                throw new Exception(wronyTypeException);
            }
        }

        /// <summary>
        /// 先进先出 所以 count小的先出
        /// </summary>
        /// <returns></returns>
        public Pet PollAll()
        {
            if (this.dogQ.Count!=0&&this.catQ.Count!=0)
            {
                if (this.catQ.Peek().Count<this.dogQ.Peek().Count)
                {
                    return catQ.Dequeue().Pet;

                }
                else
                {
                    return dogQ.Dequeue().Pet;
                }
            }
            else if (this.dogQ.Count!=0)
            {
                return dogQ.Dequeue().Pet;
            }
            else if (this.catQ.Count != 0)
            {
                return catQ.Dequeue().Pet;
            }
            else
            {
                throw new Exception(petEmptyException);
            }
        }

        public Dog PollDog()
        {
            if (dogQ.Count==0)
            {
                throw new Exception(petEmptyException);
            }
            else
            {
              return  (Dog)dogQ.Dequeue().Pet;
            }
        }

        public Cat PollCat()
        {
            if (catQ.Count == 0)
            {
                throw new Exception(petEmptyException);
            }
            else
            {
                return (Cat)catQ.Dequeue().Pet;
            }
        }

        public bool IsEmpty()
        {
            return dogQ.Count == 0 && catQ.Count == 0;
        }

        public void Run()
        {
            Assert.IsTrue(this.IsEmpty());
            this.AddPet(new Dog("d1"));
            Assert.IsFalse(this.IsEmpty());
            this.AddPet(new Cat("c1"));
            this.AddPet(new Dog("d2"));
            this.AddPet(new Cat("c2"));

            Assert.AreEqual("c1", this.PollCat().Name);
            Assert.AreEqual("d1", this.PollAll().Name);
            Assert.AreEqual("d2", this.PollDog().Name);


        }
    }

    public class PetEnterQueue
    {

        public PetEnterQueue(Pet p, long c)
        {
            this.Pet = p;
            this.Count = c;
        }

        public Pet Pet { get; set; }

        public long Count { get; set; }

        public PetType Type
        {
            get
            {
                return Pet.Type;
            }
        }
    }

    public class Pet
    {
        public PetType Type { get; set; }

        public string Name { get; set; }
        public Pet(PetType type,string name)
        {
            this.Type = type;
            this.Name = name;
        }
    }

    public class Dog : Pet
    {
        public Dog(string name) : base( PetType.Dog,name)
        {

        }
    }
    public class Cat : Pet
    {
        public Cat(string name) : base(PetType.Cat, name)
        {

        }
    }

    public enum PetType
    {
        Dog,
        Cat
    }
}
