using UnityEngine;

namespace Marvest.Sounds
{
    public class SoundEffect : MonoBehaviour
    {
        public AudioClip SeHit;
        public AudioClip SeBulletHit;

        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayHitSe()
        {
            audioSource.PlayOneShot(SeHit);
        }

        public void PlayBulletHitSe()
        {
            audioSource.PlayOneShot(SeBulletHit);
        }
    }
}