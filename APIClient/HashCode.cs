using System;
using System.Collections;

namespace VersionOne.SDK.APIClient
{
	/// <summary>
	/// Generate good hashcode from integer data.
	/// </summary>
	/// <remarks>
	/// Adapted from Paul Hsieh's SuperFastHash.
	/// http://www.azillionmonkeys.com/qed/hash.html
	/// </remarks>
	public class HashCode
	{
		// Borrowed from FNV hash algorithm's 32-bit prime multiplier
		private const uint magic = 16777619u;

		public static int Hash(uint data1)
		{
			uint hash = magic;
			hash = MixHash(hash, data1);
			return (int) PostHash(hash);
		}

		public static int Hash(int data1)
		{
			return Hash((uint) data1);
		}

		public static int Hash(object data1)
		{
			return Hash((uint) data1.GetHashCode());
		}


		public static int Hash(uint data1, uint data2)
		{
			uint hash = magic;
			hash = MixHash(hash, data1);
			hash = MixHash(hash, data2);
			return (int) PostHash(hash);
		}

		public static int Hash(int data1, int data2)
		{
			return Hash((uint) data1, (uint) data2);
		}

		public static int Hash(object data1, object data2)
		{
			return Hash((uint) data1.GetHashCode(), (uint) data2.GetHashCode());
		}


		public static int Hash(uint data1, uint data2, uint data3)
		{
			uint hash = magic;
			hash = MixHash(hash, data1);
			hash = MixHash(hash, data2);
			hash = MixHash(hash, data3);
			return (int) PostHash(hash);
		}

		public static int Hash(int data1, int data2, int data3)
		{
			return Hash((uint) data1, (uint) data2, (uint) data3);
		}

		public static int Hash(object data1, object data2, object data3)
		{
			return Hash((uint) data1.GetHashCode(), (uint) data2.GetHashCode(), (uint) data3.GetHashCode());
		}


		public static int Hash(params int[] data)
		{
			uint hash = magic;
			foreach (int datum in data)
				hash = MixHash(hash, (uint) datum);
			return (int) PostHash(hash);
		}

		public static int Hash(byte[] data)
		{
			uint hash = magic;
			foreach (byte datum in data)
				hash = MixHash(hash, datum);
			return (int) PostHash(hash);
		}

		public static int Hash(params object[] data)
		{
			uint hash = magic;
			foreach (object datum in data)
				hash = MixHash(hash, (uint) datum.GetHashCode());
			return (int) PostHash(hash);
		}

		public static int Hash(IEnumerable data)
		{
			uint hash = magic;
			foreach (object datum in data)
				hash = MixHash(hash, (uint) datum.GetHashCode());
			return (int) PostHash(hash);
		}


		public static int Hash(String data)
		{
			uint hash = magic;
			foreach (char datum in data)
				hash = MixHash(hash, datum);
			return (int) PostHash(hash);
		}


		private static uint MixHash(uint hash, uint data)
		{
			unchecked
			{
				uint lo16 = data & 0xFFFFu;
				uint hi16 = data >> 16;
				hash += lo16;
				hash ^= hash << 16;
				hash ^= hi16 << 11;
				hash += hash >> 11;
				return hash;
			}
		}

		private static uint PostHash(uint hash)
		{
			unchecked
			{
				hash ^= hash << 3;
				hash += hash >> 5;
				hash ^= hash << 2;
				hash += hash >> 15;
				hash ^= hash << 10;
				return hash;
			}
		}


		private uint _hash = magic;

		public void Mix(uint data)
		{
			_hash = MixHash(_hash, data);
		}

		public void Mix(int data)
		{
			Mix((uint) data);
		}

		public void Mix(object data)
		{
			Mix((uint) data.GetHashCode());
		}

		public int Value
		{
			get { return (int) PostHash(_hash); }
		}
	}
}